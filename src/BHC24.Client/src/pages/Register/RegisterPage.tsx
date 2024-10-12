import React from 'react';
import { useForm } from 'react-hook-form';
import AnimatedMain from '../../components/AnimatedComps/AnimatedMain';
import { useRegister } from '../../hooks/useRegister';

interface IFormInput {
  name: string;
  surname: string;
  email: string;
  password: string;
}

export function RegisterPage() {
  const { register, handleSubmit, formState: { errors } } = useForm<IFormInput>();

  const submitRegister = useRegister();

  const onSubmit = async (data: IFormInput) => {
    const registerResult = await submitRegister.mutateAsync(data);

    console.log(registerResult);
  };

  return (
    <AnimatedMain>
      <h1>Register Form</h1>
      <form onSubmit={handleSubmit(onSubmit)}>
        <div>
          <label>First name:</label>
          <input
            type="text"
            {...register("name", {
              required: "First name is required",
            })}
          />
          {errors.name && <span>{errors.name.message}</span>}
        </div>

        <div>
          <label>Last name:</label>
          <input
            type="text"
            {...register("surname", {
              required: "Last name is required",
            })}
          />
          {errors.surname && <span>{errors.surname.message}</span>}
        </div>

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
