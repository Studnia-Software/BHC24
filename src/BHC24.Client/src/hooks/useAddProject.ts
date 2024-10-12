import { useMutation } from "@tanstack/react-query";
import { AddProjectRequest, ApiResponse } from "../utils/models";
import { api } from "../utils/axiosInstance";
import urlJoin from "url-join";
import { ApiRoutes } from "../utils/apiRoutes";

export const useAddProject = () => useMutation({
  mutationFn: async (data: AddProjectRequest) => {
    return (await api.post<ApiResponse>(urlJoin(ApiRoutes.PROJECTS), data)).data
  }
})