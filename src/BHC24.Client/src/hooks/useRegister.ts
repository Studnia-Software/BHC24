import { useMutation } from "@tanstack/react-query";
import { ApiResponseData, RegisterRequest } from "../utils/models";
import { ApiRoutes } from "../utils/apiRoutes";
import urlJoin from "url-join";
import { api } from "../utils/axiosInstance";

export const useLogin = () => useMutation({
  mutationFn: async (data: RegisterRequest) => {
    const url = urlJoin(ApiRoutes.AUTH, 'login');
    return (await api.post<ApiResponseData<string>>(url, data)).data;
  }
});