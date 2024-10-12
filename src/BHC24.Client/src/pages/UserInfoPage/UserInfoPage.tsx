import {JSX} from "react";
import LoadingAnimation from "../../components/LoadingAnimation/LoadingAnimation.tsx";
import AnimatedDiv from "../../components/AnimatedComps/AnimatedDiv.tsx";
import AnimatedMain from "../../components/AnimatedComps/AnimatedMain.tsx";

const user = null;

function UserInfoPage(): JSX.Element {
  return (
    <AnimatedMain>
      {user ? (
        <AnimatedDiv key={"user"}><h2>User</h2></AnimatedDiv>
      ) : (
        <LoadingAnimation/>
      )}
    </AnimatedMain>
  );
}

export default UserInfoPage;