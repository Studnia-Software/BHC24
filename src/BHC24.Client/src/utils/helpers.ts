import { PaginationResponse } from "./models";

export function isLastPage(response: PaginationResponse<any>) {
  return response.totalCount <= response.page * response.pageSize;
}