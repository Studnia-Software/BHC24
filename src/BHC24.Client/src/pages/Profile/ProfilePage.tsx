import AnimatedMain from "../../components/AnimatedComps/AnimatedMain";
import styles from "./ProfilePage.module.css";
import myImg from "../../assets/pic.jpg";
import { useParams } from "react-router-dom";
import { useGetProfile } from "../../hooks/useGetProfile";
import { TagBlock } from "../../components/TagBlock/TagBlock";
import { Divider } from "../../components/Divider/Divider";
import { ProjectItem } from "../../components/ProjectItem";

export function ProfilePage() {
  const params = useParams<{ id: string }>();

  const { data: profile, isLoading, error } = useGetProfile(params.id!);

  const UserSection = () => {
    return (
      <section>
        <div className={styles.userHeader}>
          <img src={myImg} className={styles.userImage} />
          <div className={styles.userName} style={{ fontSize: '2.5rem' }}>
            <h2 >{profile?.data?.firstName} {profile?.data?.lastName}</h2>
            <p style={{ textAlign: 'center', fontSize: '1.25rem' }}>@{profile?.data?.userName}</p>
          </div>
        </div>

        <div style={{ fontSize: 24, marginTop: '4rem' }}>
          Opis użytkownika:  Lorem ipsum dolor sit amet, consectetur adipiscing elit.
          Vestibulum laoreet ligula in porttitor congue. Sed euismod lectus et feugiat porta.
          Proin finibus mauris ac mauris rutrum venenatis. Ut gravida condimentum accumsan.
          Etiam congue nulla pellentesque lobortis dignissim. Maecenas nec nisi in nisi hendrerit aliquam.
          Pellentesque placerat vitae lectus id ullamcorper.
        </div>
      </section>
    )
  }

  const SkillsSection = () => {
    return (
      <section>
        <div>
          <h2 style={{ marginBottom: '0.5rem' }}>Umiejętności</h2>
          <Divider />
          <div style={{ display: 'flex', justifyContent: 'center', gap: '1rem', marginBlock: '2rem', flexWrap: 'wrap' }}>
            {profile?.data?.tags.map(tag => (
              <TagBlock key={tag.id} tag={tag} />
            ))}
          </div>
        </div>
      </section>
    )
  }

  const ProjectsSection = () => {
    return (
      <section>
        <div>
          <h2 style={{ marginBottom: '0.5rem' }}>Projekty</h2>
          <Divider />
          <div style={{ display: 'flex', flexDirection: 'column', justifyContent: 'center', gap: '1rem', marginBlock: '2rem', flexWrap: 'wrap' }}>
            {profile?.data?.projects.map(project => (
              <ProjectItem key={project.title} project={project} />
            ))}
          </div>
        </div>
      </section>
    )
  }

  return (
    <AnimatedMain>
      <>
        {isLoading && <p>Loading...</p>}
        <UserSection />
        <SkillsSection />
        <ProjectsSection />
      </>
    </AnimatedMain>
  )
}