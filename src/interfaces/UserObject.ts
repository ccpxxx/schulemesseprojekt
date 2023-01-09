export default interface UserObject {
    id: string;
    name: string;
    lastName: string;
    address: string;
    interests: string[] | undefined;
    picture: string;
    isOfficial: boolean
}