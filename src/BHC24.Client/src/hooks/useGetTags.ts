//write get tags hook

import { useQuery } from "@tanstack/react-query";
import { api } from "../utils/axiosInstance";
import urlJoin from "url-join";
import { ApiRoutes } from "../utils/apiRoutes";
import { ApiResponseData, GetTagResponse } from "../utils/models";

export const useGetTags = () => useQuery({
  queryKey: ['tags'],
  queryFn: async () => {
    const url = urlJoin(ApiRoutes.TAGS);
    return (await api.get<ApiResponseData<GetTagResponse[]>>(url)).data;
  }
});