import {FilterPagination} from "@/common/models/querying/FilterPagination";

export class ListingFilter extends FilterPagination {
    categories: Array<string> = [];

    constructor(pageSize: number, pageToken: number, categories: Array<string>) {
        super(pageSize, pageToken);
        this.categories = categories;
    }

    convertToQueryParams(): URLSearchParams {
        const params = super.convertToQueryParams();

        if (this.categories.length > 0)
            params.append("categories", this.categories.join(","));

        return params;
    }
}