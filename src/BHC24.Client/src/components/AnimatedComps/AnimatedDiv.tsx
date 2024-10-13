import {JSX} from "react";
import {framerOpacityVariants} from "../../utils/globalVariables.ts";
import {FramerVariants} from "../../utils/models.ts";
import {motion} from "framer-motion";

interface AnimatedDivProps {
  children: JSX.Element | JSX.Element[] | string | string[] | number | number[]
  className?: string
}

function AnimatedDiv({children, className}: AnimatedDivProps): JSX.Element {
  return (
    <motion.div variants={framerOpacityVariants} initial={FramerVariants.INITIAL}
                animate={FramerVariants.ANIMATE} exit={FramerVariants.EXIT} transition={{duration: 0.3}}
                className={className}>
      {children}
    </motion.div>
  );
}

export default AnimatedDiv;