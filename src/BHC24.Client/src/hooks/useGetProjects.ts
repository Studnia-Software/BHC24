import { useQuery } from "@tanstack/react-query";
import urlJoin from "url-join";
import { ApiRoutes } from "../utils/apiRoutes";
import { api } from "../utils/axiosInstance";
import { ApiResponseData, GetProjectResponse, GetProjectsRequest, PaginationRequest, PaginationResponse } from "../utils/models";

export function useGetProjects(request: GetProjectsRequest, paginationRequest: PaginationRequest) {
  return useQuery({
    queryKey: ['projects', request, paginationRequest],
    queryFn: async () => {
      if (request.projectName === '' && request.tags?.length === 0 && request.ownerName === '') {
        return {
          data: {
            data: [],
            page: 1,
            pageSize: 10,
            totalCount: 0
          }
        }
      }

      const url = urlJoin(ApiRoutes.SEARCH, 'projectByName');
      return (await api.get<ApiResponseData<PaginationResponse<GetProjectResponse>>>(url, {
        params: {
          projectName: request.projectName,
          page: paginationRequest.page,
          pageSize: paginationRequest.pageSize,
          tagNames: request.tags?.join(','),
          ownerName: request.ownerName,
        }
      })).data;
    }
  });
}