export enum FramerPageSwapVariants {
  INITIAL = "initial",
  ANIMATE = "animate",
  EXIT = "exit"
}

export type StatusCode = {
  OK: 200,
  BAD_REQUEST: 400,
  NOT_FOUND: 404,
}

export type ApiResponse = {
  isSuccess: boolean;
  message: string;
  statusCode: StatusCode,
}

export type ApiResponseData<T> = ApiResponse & {
  data: T | null;
}

export type LoginRequest = {
  email: string;
  password: string;
}

export type RegisterRequest = {
  name: string;
  surname: string;
  email: string;
  password: string;
}