import { LocationEndpointsClient } from "./LocationEndpointsClient";
import { LocationCategoriesEndpointsClients } from "./LocationCategoriesEndpointsClients";
import ApiClientBase from "@/infrastructures/apiClients/apiClientBase/ApiClientBase";

export class AirBnbApiClient {
    private readonly client: ApiClientBase;
    public readonly baseUrl: string;

    constructor() {
        this.baseUrl = "https://localhost:7198";

        this.client = new ApiClientBase({
            baseURL: this.baseUrl
        });

        this.locations = new LocationEndpointsClient(this.client);
        this.locationCategories = new LocationCategoriesEndpointsClients(this.client);
    }

    public locations: LocationEndpointsClient;

    public locationCategories: LocationCategoriesEndpointsClients;
}