export interface Pagination {
	currentPage: number;
	itemsPerPage: number;
	totalItems: number;
	totalPages: number;
}

export class PaginatedResult<T> {
	result: T; // we are using for any classes: message and user
	pagination: Pagination; // header information
}
