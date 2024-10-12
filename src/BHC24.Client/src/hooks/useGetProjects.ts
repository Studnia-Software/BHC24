import { useQuery } from "@tanstack/react-query";
import urlJoin from "url-join";
import { ApiRoutes } from "../utils/apiRoutes";
import { api } from "../utils/axiosInstance";
import { ApiResponseData, GetProjectResponse, PaginationRequest, PaginationResponse } from "../utils/models";

export function useGetProjects(projectName: string, paginationRequest: PaginationRequest) {
  return useQuery({
    queryKey: ['projects', projectName, paginationRequest],
    queryFn: async () => {
      const url = urlJoin(ApiRoutes.SEARCH, 'projectByName');
      return (await api.get<ApiResponseData<PaginationResponse<GetProjectResponse>>>(url, {
        params: {
          page: paginationRequest.page,
          pageSize: paginationRequest.pageSize,
          projectName: projectName
        }
      })).data;
    }
  });
}