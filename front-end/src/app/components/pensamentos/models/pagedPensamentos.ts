import { Pensamento } from "./pensamento";

export interface PagedPensamentos {
  "orderByProperty": string;
	"pageNumber": Number;
	"pageSize": Number;
	"totalPages": Number;
	"totalRegisters": Number;
  "reverse": boolean;
	"data": Pensamento[];
}
