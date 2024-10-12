import {JSX} from "react";
import {framerPageSwapVariants} from "../../utils/globalVariables.ts";
import {FramerPageSwapVariants} from "../../utils/models.ts";
import {motion} from "framer-motion";

interface AnimatedMainProps {
    children: JSX.Element | JSX.Element[];
}

function AnimatedMain({children}: AnimatedMainProps): JSX.Element {
    return (
        <motion.main variants={framerPageSwapVariants} initial={FramerPageSwapVariants.INITIAL}
                     animate={FramerPageSwapVariants.ANIMATE} exit={FramerPageSwapVariants.EXIT} transition={{duration: 0.3}}>
            {children}
        </motion.main>
    );
}

export default AnimatedMain;