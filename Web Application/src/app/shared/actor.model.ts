export class Actor {
    id: number;
    name: string;
    
    movieName: string[];
    movieId: number[];

    img: string;
  
    constructor(input?: any) {
      Object.assign(this, input);
    }
  }