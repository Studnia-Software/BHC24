import {JSX, useEffect, useState} from "react";
import LoadingAnimation from "../../components/LoadingAnimation/LoadingAnimation.tsx";
import {AnimatePresence} from "framer-motion";
import AnimatedDiv from "../../components/AnimatedComps/AnimatedDiv.tsx";

function UserInfoPage(): JSX.Element {
  const [user, setUser] = useState<null | object>(null);

  useEffect(() => {
    setTimeout(() => {
      setUser({
        firstName: "John",
        lastName: "Doe",
        id_nickname: "@id_nickname",
        email: "email@email.com",
        github: "github_nick",
        linkedin: "linkedin_nick",
        phoneNumber: "123456789",
        cv: "cv_link",
        projects: [{}],
        tags: [{}],
        profilePicture: "profile_picture_link",
        about: "about_text",
      });
    }, 2000);
  }, []);

  return (
    <AnimatePresence mode={"wait"}>
      {user ? (
        <AnimatedDiv key={"user"}><h2>User</h2></AnimatedDiv>
      ) : (
        <LoadingAnimation/>
      )}
    </AnimatePresence>
  );
}

export default UserInfoPage;