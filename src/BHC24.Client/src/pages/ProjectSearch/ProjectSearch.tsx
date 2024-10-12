import { useState } from "react";
import AnimatedMain from "../../components/AnimatedComps/AnimatedMain";
import { Divider } from "../../components/Divider/Divider";
import { useGetProjects } from "../../hooks/useGetProjects";
import { PaginationRequest } from "../../utils/models";
import { isLastPage } from "../../utils/helpers";

export function ProjectSearch() {
  const [pagination, setPagination] = useState<PaginationRequest>({ page: 1, pageSize: 10 });
  const [searchQuery, setSearchQuery] = useState<string>('');
  const { data: projects, isLoading, error } = useGetProjects(searchQuery, pagination);

  const FilterSection = () => {
    return (
      <div style={{ width: '100%' }}>
        <h3 style={{ textAlign: 'center', marginBottom: '1rem' }}>Filtry</h3>
        <Divider />
        <div>
          <label>Tytuł</label>
          <input type="text" id="title" />
        </div>
        <div>
          <label>Właściciel</label>
          <input type="text" id="owner" />
        </div>
        <div>
          <label>Współpracownicy</label>
          <input type="text" id="collaborators" />
        </div>
      </div>
    );
  }

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
    <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center' }}>
      <button
        onClick={() => setPagination({ ...pagination, page: pagination.page - 1 })}
        disabled={pagination.page === 1}>
        Poprzednia
      </button>
      <div>{pagination.page}</div>
      <button
        onClick={() => setPagination({ ...pagination, page: pagination.page + 1 })}
        disabled={projects?.data == null ? false : isLastPage(projects?.data!)}>
        Następna
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
      <FilterSection />
      <SearchResults />
      <PaginationInput />
    </AnimatedMain>
  );
}