export default interface UserObject {
    firstname: string;
    name: string;
    address: string;
    interests: string[] | undefined;
    picture: string;
    company: string | boolean;
}