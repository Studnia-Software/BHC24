import React from 'react';
import { useForm } from 'react-hook-form';
import AnimatedMain from '../../components/AnimatedComps/AnimatedMain';
import { useLogin } from '../../hooks/useLogin';

interface IFormInput {
  email: string;
  password: string;
}

export function LoginPage() {
  const { register, handleSubmit, formState: { errors } } = useForm<IFormInput>();

  const submitLogin = useLogin();

  const onSubmit = async (data: IFormInput) => {
    const loginResult = await submitLogin.mutateAsync(data);

    if(!loginResult.isSuccess) {
      console.log("Login not succeeded");
    }
  };

  return (
    <AnimatedMain>
      <h1>Login Form</h1>
      <form onSubmit={handleSubmit(onSubmit)}>
        <div>
          <label>Email:</label>
          <input
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
          <label>Password:</label>
          <input
            type="password"
            {...register("password", { required: "Password is required" })}
          />
          {errors.password && <span>{errors.password.message}</span>}
        </div>

        <button type="submit">Submit</button>
      </form>
    </AnimatedMain>
  );
}
