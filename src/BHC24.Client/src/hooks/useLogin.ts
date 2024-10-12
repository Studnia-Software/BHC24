import { useMutation, useQuery } from "@tanstack/react-query";
import { api } from "../utils/axiosInstance";
import { ApiResponseData, LoginRequest } from "../utils/models";
import urlJoin from "url-join";
import { ApiRoutes } from "../utils/apiRoutes";

export const useLogin = () => useMutation({
  mutationFn: async (data: LoginRequest) => {
    const url = urlJoin(ApiRoutes.AUTH, 'login');
    return (await api.post<ApiResponseData<string>>(url, data)).data;
  }
});