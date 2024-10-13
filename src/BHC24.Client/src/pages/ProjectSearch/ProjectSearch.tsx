import { useEffect, useState } from "react";
import { faAngleLeft, faAngleRight } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import AnimatedMain from "../../components/AnimatedComps/AnimatedMain";
import { Divider } from "../../components/Divider/Divider";
import { useGetProjects } from "../../hooks/useGetProjects";
import { GetTagResponse, PaginationRequest } from "../../utils/models";
import { isLastPage } from "../../utils/helpers";
import styles from './ProjectSearch.module.css';
import { useGetTags as useGetTags } from "../../hooks/useGetTags";

export function ProjectSearch() {
  const [pagination, setPagination] = useState<PaginationRequest>({ page: 1, pageSize: 10 });
  const [searchQuery, setSearchQuery] = useState<string>('');
  const [selectedTags, setSelectedTags] = useState<GetTagResponse[]>([]);
  const [ownerName, setOwnerName] = useState<string>('');
  const { data: tags } = useGetTags();

  const { data: projects, isLoading, error, refetch } = useGetProjects({
    projectName: searchQuery,
    tags: selectedTags.map(t => t.name),
    ownerName: ownerName
  }, pagination);

  useEffect(() => {
    refetch();
  }, [searchQuery, pagination, tags, ownerName]);

  const SearchResults = () => (
    <div style={{ width: '100%' }}>
      {isLoading && searchQuery !== '' && <p>Loading...</p>}
      {error && <p>Error: {error.message}</p>}
      {projects && searchQuery !== '' && projects.data?.data.map((project, index) => (
        <div key={index} style={{ marginBlock: '1rem' }}>
          <h3 style={{ color: 'var(--color-text)' }}>{project.title}</h3>
          <p>{project.description}</p>
          <p>Właściciel: <a href='#' style={{ textDecoration: 'underline' }}>{project.owner}</a></p>
          <p>Współpracownicy: {project.collaborators.join(', ').length}</p>
          <Divider />
        </div>
      ))}
    </div>
  );

  const PaginationInput = () => (
    <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', fontSize: '2rem' }}>
      <button
        onClick={() => setPagination({ ...pagination, page: pagination.page - 1 })}
        className={styles.paginationArrow}
        disabled={pagination.page === 1}>
        <FontAwesomeIcon icon={faAngleLeft} />
      </button>
      <div>{pagination.page}</div>
      <button
        onClick={() => setPagination({ ...pagination, page: pagination.page + 1 })}
        disabled={projects?.data == null ? false : isLastPage(projects?.data)}
        className={styles.paginationArrow}>
        <FontAwesomeIcon icon={faAngleRight} />
      </button>
    </div>
  );

  return (
    <AnimatedMain>
      <h2>Wyszukiwarka projektów</h2>
      <input type="text"
        onChange={(e) => {
          setSearchQuery(e.target.value)
          setPagination({ page: 1, pageSize: 10 });
        }}
        style={{
          backgroundColor: 'var(--color-grey)',
          padding: '0.5rem',
          fontSize: '1.5rem',
          color: 'var(--color-background)'
        }} />
      <div style={{ width: '100%' }}>
        <h3 style={{ textAlign: 'center', marginBottom: '1rem' }}>Filtry</h3>
        <Divider />
        <div>
          <label>Tagi</label>
          <div style={{
            display: "flex",
            gap: '0.25rem',
          }}>
            {tags && tags.data?.map((tag) => (
              <div key={tag.name}
                style={{
                  width: '5rem',
                  height: '5rem',
                  padding: '0.5rem',
                  backgroundColor: selectedTags.some(t => t.name === tag.name) ? 'var(--color-primary' : 'white',
                  borderRadius: '15%',
                  cursor: 'pointer',
                }}
                onClick={() => {
                  setSelectedTags(prevSelectedTags => {
                    if (prevSelectedTags.some(t => t.name === tag.name)) {
                      return prevSelectedTags.filter(t => t.name !== tag.name);
                    } else {
                      return [...prevSelectedTags, tag];
                    }
                  });
                }}>
                <img src={tag.imagePath} style={{ width: '100%', height: '100%' }} />
              </div>
            ))}
          </div>
        </div>
        <div>
          <label>Właściciel</label>
          <input type="text" id="ownerName" onChange={(e) => setOwnerName(e.target.value)} />
        </div>
        <div>
          <label>Współpracownicy</label>
          <input type="text" id="collaborators" />
        </div>
      </div>
      <SearchResults />
      <PaginationInput />
    </AnimatedMain>
  );
}
