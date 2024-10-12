import {JSX} from "react";
import {framerOpacityVariants} from "../../utils/globalVariables.ts";
import {FramerVariants} from "../../utils/models.ts";
import {motion} from "framer-motion";

interface AnimatedMainProps {
  children: JSX.Element | JSX.Element[];
}

function AnimatedMain({children}: AnimatedMainProps): JSX.Element {
  return (
    <motion.main variants={framerOpacityVariants} initial={FramerVariants.INITIAL}
                 animate={FramerVariants.ANIMATE} exit={FramerVariants.EXIT} transition={{duration: 0.5}}>
      {children}
    </motion.main>
  );
}

export default AnimatedMain;