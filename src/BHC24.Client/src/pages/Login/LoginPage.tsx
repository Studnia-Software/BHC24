import { useForm } from "react-hook-form";
import { useLogin } from "../../hooks/useLogin";

interface IFormInput {
  email: string;
  password: string;
}

export function LoginPage() {
  const { register, handleSubmit } = useForm<IFormInput>();
  const loginSubmit = useLogin();

  const onSubmit = (data: IFormInput) => {
    loginSubmit.mutate(data);
  }

  return (
    <div>
      <h1>Log in to continue</h1>
      <form onSubmit={handleSubmit(onSubmit)}>
        <label>Email</label>
        <input type="email" {...register("email", { required: true })} />
        <label>Password</label>
        <input type="password" {...register("password", { required: true })} />
        <input type="submit"/>
      </form>
    </div>
  );
}