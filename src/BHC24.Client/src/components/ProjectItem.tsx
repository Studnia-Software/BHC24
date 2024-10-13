import { GetProjectResponse } from "../utils/models";
import { Divider } from "./Divider/Divider";
import { TagBlock } from "./TagBlock/TagBlock";

export const ProjectItem = ({ project }: { project: GetProjectResponse }) => (
  <div key={project.title} style={{ marginBlock: '1rem' }}>
    <h3 style={{ color: 'var(--color-text)' }}>{project.title}</h3>
    <p>{project.description}</p>
    <p>Właściciel: <a href={'profile/' + project.ownerId} style={{ textDecoration: 'underline' }}>{project.owner}</a></p>
    <p>Współpracownicy: {project.collaboratorsCount}</p>
    <div style={{ display: 'flex', gap: '0.5rem', marginBlock: '1rem' }}>
      {project.tags.map(tag => (
        <TagBlock key={tag.name} tag={tag} />
      ))}
    </div>
    <Divider />
  </div>
)