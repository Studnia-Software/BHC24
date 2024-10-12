import {useForm} from 'react-hook-form';
import AnimatedMain from '../../../components/AnimatedComps/AnimatedMain.tsx';
import {useLogin} from '../../../hooks/useLogin.ts';
import BlurBg from "../../../components/BlurBg/BlurBg.tsx";
import DisplayButton from "../../../components/Buttons/DisplayButton.tsx";
import styles from "../Auth.module.css";
import {useNavigate} from "react-router-dom";

interface IFormInput {
  email: string;
  password: string;
}

export function LoginPage() {
  const {register, handleSubmit, formState: {errors}} = useForm<IFormInput>();

  const submitLogin = useLogin();
  const navigate = useNavigate();

  const onSubmit = async (data: IFormInput) => {
    const loginResult = await submitLogin.mutateAsync(data);

    if (!loginResult.isSuccess) {
      console.log("Login not succeeded");
    }
  };

  return (
    <AnimatedMain>
      <div className={styles.authCon}>
        <article>
          <h2>Zaloguj się</h2>
          <form onSubmit={handleSubmit(onSubmit)}>
            <BlurBg/>
            <div>
              <input
                placeholder={"Email"}
                type="email"
                {...register("email", {
                  required: "Email jest wymagany",
                  pattern: {
                    value: /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/,
                    message: "Zły format email"
                  }
                })}
              />
              {errors.email && <span>{errors.email.message}</span>}
            </div>

            <div>
              <input
                placeholder={"Hasło"}
                type="password"
                {...register("password", {required: "Hasło jest wymagane"})}
              />
              {errors.password && <span>{errors.password.message}</span>}
            </div>

            <DisplayButton type="submit" text={"Zaloguj"}/>
          </form>
        </article>
        <article className={styles.changeWindowBox}>
          <h2>Nie masz jeszcze konta?
          </h2>
          <h4>Zostań częścią naszej społeczności i znajdź projekt, w którym nareszcie poczujesz spełnienie!</h4>
          <DisplayButton fill text="Załóż konto" onClick={() => navigate('/auth/register')}/>
        </article>
      </div>
    </AnimatedMain>
  );
}
