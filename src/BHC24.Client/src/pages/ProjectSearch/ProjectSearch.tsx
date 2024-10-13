import {useEffect, useState} from "react";
import {faAngleLeft, faAngleRight} from "@fortawesome/free-solid-svg-icons";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import AnimatedMain from "../../components/AnimatedComps/AnimatedMain";
import {Divider} from "../../components/Divider/Divider";
import {useGetProjects} from "../../hooks/useGetProjects";
import {GetTagResponse, PaginationRequest} from "../../utils/models";
import {isLastPage} from "../../utils/helpers";
import styles from './ProjectSearch.module.css';
import {useGetTags as useGetTags} from "../../hooks/useGetTags";
import { ProjectItem } from "../../components/ProjectItem";
import AnimatedDiv from "../../components/AnimatedComps/AnimatedDiv.tsx";
import {AnimatePresence} from "framer-motion";

export function ProjectSearch() {
  const [pagination, setPagination] = useState<PaginationRequest>({page: 1, pageSize: 10});
  const [searchQuery, setSearchQuery] = useState<string>('');
  const [selectedTags, setSelectedTags] = useState<GetTagResponse[]>([]);
  const [ownerName, setOwnerName] = useState<string>('');
  const {data: tags} = useGetTags();

  const {data: projects, isLoading, error, refetch} = useGetProjects({
    projectName: searchQuery,
    tags: selectedTags.map(t => t.name),
    ownerName: ownerName
  }, pagination);

  useEffect(() => {
    refetch();
  }, [searchQuery, pagination, tags, ownerName, refetch]);

  const SearchResults = () => (
    <div style={{width: '100%'}}>
      {isLoading && searchQuery !== '' && <p>Loading...</p>}
      {error && <p>Error: {error.message}</p>}
      {projects && searchQuery !== '' && projects.data?.data.map((project, index) => (
        <ProjectItem key={index} project={project} />
      ))}
    </div>
  );

  const PaginationInput = () => (
    <div style={{display: 'flex', justifyContent: 'center', alignItems: 'center', fontSize: '2rem'}}>
      <button
        onClick={() => setPagination({...pagination, page: pagination.page - 1})}
        className={styles.paginationArrow}
        disabled={pagination.page === 1}>
        <FontAwesomeIcon icon={faAngleLeft}/>
      </button>
      <AnimatePresence mode={"wait"}><AnimatedDiv
        key={pagination.page}>{pagination.page}</AnimatedDiv></AnimatePresence>
      <button
        onClick={() => setPagination({...pagination, page: pagination.page + 1})}
        disabled={projects?.data == null ? false : isLastPage(projects?.data)}
        className={styles.paginationArrow}>
        <FontAwesomeIcon icon={faAngleRight}/>
      </button>
    </div>
  );

  return (
    <AnimatedMain>
      <h2>Wyszukiwarka projektów</h2>
      <input type="text"
             placeholder={'Wyszukaj projekt...'}
             onChange={(e) => {
               setSearchQuery(e.target.value)
               setPagination({page: 1, pageSize: 10});
             }}/>
      <div style={{width: '100%'}}>
        <h3 style={{textAlign: 'center', marginBottom: '1rem'}}>Filtry</h3>
        <Divider/>
        <div>
          <div style={{
            display: "flex",
            justifyContent: 'center',
            alignItems: 'center',
            gap: '3rem',
            marginTop: '3rem',
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
                  userSelect: 'none',
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
                <img src={tag.imagePath} draggable='false' style={{ width: '100%', height: '100%' }} />
              </div>
            ))}
          </div>
        </div>
        <div style={{ marginBlock: '2rem' }}>
          <label>Właściciel</label>
          <input type="text" id="ownerName" onChange={(e) => setOwnerName(e.target.value)}/>
        </div>
      </div>
      <SearchResults/>
      <PaginationInput/>
    </AnimatedMain>
  );
}
