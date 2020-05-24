export class Movie {
    id: number;
    title: string; 
    releaseDate: string;
    runtime: number;
    vote: number;

    actorId: number[];
    actorName: string[];
    companyId: number[];
    companyName: string[];
    genreId: number[];
    genreName: string[];

    img: string;

    constructor(input?: any) {
      Object.assign(this, input);
    }
}