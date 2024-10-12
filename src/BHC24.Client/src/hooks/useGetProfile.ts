import { useQuery } from "@tanstack/react-query";
import urlJoin from "url-join";
import { ApiRoutes } from "../utils/apiRoutes";
import { api } from "../utils/axiosInstance";
import { ApiResponseData, GetProfileResponse } from "../utils/models";

export const useGetProfile = (userId: string) => useQuery({
  queryKey: ["profile", userId],
  queryFn: async () => {
    const url = urlJoin(ApiRoutes.PROFILE, userId);
    return (await api.get<ApiResponseData<GetProfileResponse>>(url)).data
  }
})