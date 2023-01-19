export interface CustomerInterface {
    pkCustomer:     number
    name:           string;
    lastName:       string;
    address?:       string;
    user:           string;
    password?:      string;
    fkRole:         number;
    isAvailable:    boolean;
    lastUpdated:    Date;
}