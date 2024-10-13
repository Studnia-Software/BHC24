export enum FramerVariants {
    INITIAL = "initial",
    ANIMATE = "animate",
    EXIT = "exit"
}

export type StatusCode = {
  OK: 200,
  BAD_REQUEST: 400,
  NOT_FOUND: 404,
}

export type PaginationResponse<T> = {
  data: T[];
  totalCount: number;
  page: number;
  pageSize: number;
}

export type UserModel = {
  id: string;
  name: string;
  surname: string;
  email: string;
}

export type GetProjectsRequest = {
  projectName: string;
  tags?: string[];
  ownerName?: string;
}

export type GetTagResponse = {
  id: number;
  name: string;
  imagePath: string;
}

export type GetProfileResponse = {
  githubAccountUrl: string;
  linkedInAccountUrl: string;
  profilePicture: string;
  userCv: string;
  description: string;
  appUser: UserModel;
}

export type PaginationRequest = {
  page: number;
  pageSize: number;
}

export type GetProjectResponse = {
  title: string;
  description: string;
  owner: string;
  collaboratorsCount: number;
  collaborators: string[];
  tags: GetTagResponse[];
}

export type AddProjectRequest = {
  title: string;
  description: string;
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