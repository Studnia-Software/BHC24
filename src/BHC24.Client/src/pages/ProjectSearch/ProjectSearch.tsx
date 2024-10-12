import AnimatedMain from "../../components/AnimatedComps/AnimatedMain";
import { Divider } from "../../components/Divider/Divider";
import { useGetProjects } from "../../hooks/useGetProjects";

export function ProjectSearch() {
  const useProjects = useGetProjects();

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

  return (
    <AnimatedMain>
      <h2>Wyszukiwarka projektów</h2>
      <input type="text"
        style={{
          backgroundColor: 'var(--color-grey)',
          padding: '0.5rem',
          fontSize: '1.5rem',
          color: 'var(--color-background)'
        }} />
      <FilterSection />
    </AnimatedMain>
  );
}