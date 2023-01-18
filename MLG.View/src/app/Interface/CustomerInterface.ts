export interface CustomerInterface {
    pkCustomer:     number
    name:           string;
    lastName:       string;
    Address?:       string;
    user:           string;
    password?:      string;
    fkRole:         number;
    IsAvailable:    boolean;
    LastUpdated:    Date;
}