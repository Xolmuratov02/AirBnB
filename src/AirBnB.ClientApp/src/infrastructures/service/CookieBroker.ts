export class CookieBroker {

    public get(name: string): string | null {
        const cookieName = `${name}=`;
        const cookies = Array.from(document.cookie.split(';'));
        const foundCookie = cookies.find((cookie) => cookie.trim().startsWith(cookieName));

        return foundCookie ? decodeURIComponent(foundCookie.trim().substring(cookieName.length)) : null;
    }

    public isSet(name: string): boolean {
        return this.get(name) !== null;
    }

    public set(name: string, value: string, minutes: number) {
        let expires = '';
        if(minutes) {
            const date = new Date();
            date.setTime(date.getTime() + (minutes * 60 * 1000));
            expires = "; expires=" + date.toUTCString();
        }
        document.cookie = `${name}=${encodeURIComponent(value)}${expires};domain=localhost;path=/`;
    }

}