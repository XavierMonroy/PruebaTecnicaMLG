export interface ArticleInterface {
    pkArticle:      number
    articleName:    string;
    code:           string;
    description?:   string;
    price:          number;
    image:          string;
    stock:          number;
    lastUpdated:    Date;
    isAvailable:    boolean;
}