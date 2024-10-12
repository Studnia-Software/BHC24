import {useForm} from 'react-hook-form';
import AnimatedMain from '../../../components/AnimatedComps/AnimatedMain.tsx';
import {useRegister} from '../../../hooks/useRegister.ts';
import DisplayButton from "../../../components/Buttons/DisplayButton.tsx";
import BlurBg from "../../../components/BlurBg/BlurBg.tsx";
import styles from "../Auth.module.css";
import {useNavigate} from "react-router-dom";

interface IFormInput {
  name: string;
  surname: string;
  email: string;
  password: string;
}

export function RegisterPage() {
  const {register, handleSubmit, formState: {errors}} = useForm<IFormInput>();

  const submitRegister = useRegister();
  const navigate = useNavigate();

  const onSubmit = async (data: IFormInput) => {
    const registerResult = await submitRegister.mutateAsync(data);

    console.log(registerResult);
  };

  return (
    <AnimatedMain>
      <div className={styles.authCon}>
        <article className={styles.changeWindowBox}>
          <h2>Masz już konto?
          </h2>
          <h4>Zaloguj się i kontynuuj podróż, którą z nami rozpocząłeś. Cieszymy się że dzisiaj wpadłeś!</h4>
          <DisplayButton fill text="Zaloguj się" onClick={() => navigate('/auth/login')}/>
        </article>
        <article><h2>Rejestracja</h2>
          <form onSubmit={handleSubmit(onSubmit)}>
            <BlurBg/>

            <div>
              <input
                placeholder={"Imię"}
                type="text"
                {...register("name", {
                  required: "First name is required",
                })}
              />
              {errors.name && <span>{errors.name.message}</span>}
            </div>

            <div>
              <input
                placeholder={"Nazwisko"}
                type="text"
                {...register("surname", {
                  required: "Last name is required",
                })}
              />
              {errors.surname && <span>{errors.surname.message}</span>}
            </div>

            <div>
              <input
                placeholder={"Email"}
                type="email"
                {...register("email", {
                  required: "Email is required",
                  pattern: {
                    value: /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/,
                    message: "Invalid email format"
                  }
                })}
              />
              {errors.email && <span>{errors.email.message}</span>}
            </div>

            <div>
              <input
                placeholder={"Hasło"}
                type="password"
                {...register("password", {required: "Password is required"})}
              />
              {errors.password && <span>{errors.password.message}</span>}
            </div>

            <DisplayButton type="submit" text={"Zarejestruj"}/>
          </form>
        </article>
      </div>
    </AnimatedMain>
  );
}
