import { CookieBroker } from "@/infrastructures/service/CookieBroker";
import type { UserInfo } from "@/common/models/request/UserInfo";
import axios from "axios";
import type { Region } from "@/common/models/request/Region";

export class UserInfoService {

    private readonly cookieBroker = new CookieBroker();

    /*
    Retrieves and sets user info
    */
    public set() {
        if ('geolocation' in navigator) {
            navigator.geolocation.getCurrentPosition(async (position) => {
                    const response = await axios.get<Region>(`https://api.bigdatacloud.net/data/reverse-geocode-client?latitude=${position.coords.latitude}&longitude=${position.coords.longitude}&localityLanguage=${navigator.language}`);
                    const userInfo = this.getUserInfo();

                    // Set location and region
                    userInfo.coordinates.latitude = position.coords.latitude;
                    userInfo.coordinates.longitude = position.coords.longitude;
                    userInfo.region.language = navigator.language;
                    userInfo.region.city = response.data.city;
                    userInfo.region.countryName = response.data.countryName;

                    userInfo.region.language = navigator.language;

                    this.setUserInfo(userInfo);

                }, () => {
                    // Set language
                    const userInfo = this.getUserInfo();
                    userInfo.region.language = navigator.language;
                    this.setUserInfo(userInfo);
                }
            );
        }
    }

    /*
    Checks if user info is set
     */
    public isUserInfoSet(): boolean {
        return this.cookieBroker.isSet('user-info');
    }

    /*
    Gets user info from cookies
     */
    private getUserInfo(): UserInfo {
        return this.cookieBroker.isSet('user-info') ? JSON.parse(this.cookieBroker.get('user-info')!) : {
            coordinates: {},
            region: {}
        };
    }

    /*
    Sets user info in cookies for 24 hours
     */
    private setUserInfo(userInfo: UserInfo) {
        return this.cookieBroker.set('user-info', JSON.stringify(userInfo), 1440);
    }
}