import AnimatedMain from "../../components/AnimatedComps/AnimatedMain";
import styles from "./ProfilePage.module.css";
import myImg from "../../assets/pic.jpg";

export function ProfilePage() {
  const UserSection = () => {
    return (
      <section>
        <div className={styles.userHeader}>
          <img src={myImg}  className={styles.userImage}/>
          <div className={styles.userName} style={{ fontSize: '2.5rem' }}>
            <h2 >Nazwa użytkownika</h2>
            <p style={{ textAlign: 'center', fontSize: '1.25rem' }}>@nazwa_identyfikacyjna</p>
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

  const Skills = () => {
    return (
      <section>
        <h3>Umiejętności</h3>
        <div>
          <span>HTML</span>
          <span>CSS</span>
          <span>JavaScript</span>
          <span>React</span>
          <span>Node.js</span>
        </div>
      </section>
    );
  }

  return (
    <AnimatedMain>
      <UserSection />
      <Skills />
    </AnimatedMain>
  )
}