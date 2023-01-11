export default interface UserObject {
    name: string;
    lastName: string;
    address: string;
    interests: string[] | undefined;
    picture: string;
    company: string | boolean;
}