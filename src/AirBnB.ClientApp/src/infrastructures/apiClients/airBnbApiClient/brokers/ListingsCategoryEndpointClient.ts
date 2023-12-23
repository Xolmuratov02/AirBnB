import type ApiClientBase from "@/infrastructures/apiClients/apiClientBase/ApiClientBase";
import { ListingCategory } from "@/modules/locations/models/ListingCategory";

export class ListingsCategoryEndpointClient {
    private client: ApiClientBase;

    constructor(client: ApiClientBase) {
        this.client = client;
    }

    public async getAsync() {
        return await this.client.getAsync<Array<ListingCategory>>("api/listings/categories");
    }
}