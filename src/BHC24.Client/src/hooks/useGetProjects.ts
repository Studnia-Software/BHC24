import { useQuery } from "@tanstack/react-query";
import urlJoin from "url-join";
import { ApiRoutes } from "../utils/apiRoutes";
import { api } from "../utils/axiosInstance";
import { GetProjectResponse, PaginationRequest, PaginationResponse } from "../utils/models";

export function useGetProjects(paginationRequest: PaginationRequest) {
  return useQuery({
    queryKey: ['projects', paginationRequest],
    queryFn: async () => {
      const url = urlJoin(ApiRoutes.PROJECTS, 'get-all');
      return (await api.post<PaginationResponse<GetProjectResponse>>(url, paginationRequest)).data;
    }
  });
}