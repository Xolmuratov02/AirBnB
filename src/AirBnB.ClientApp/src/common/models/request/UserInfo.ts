import { Coordinates } from "@/common/models/request/Location";
import type { Region } from "@/common/models/request/Region";

/*
Represents a user info
 */
export class UserInfo {

    /*
    User location
     */
    public coordinates!: Coordinates;

    /*
    User region
     */
    public region!: Region;
}