export interface ArticleInterface {
    pkArticle:      number
    code:           string;
    articleName:    string;
    description?:   string;
    price:          number;
    image:          string;
    stock:          number;
    IsAvailable:    boolean;
    LastUpdated:    Date;
}