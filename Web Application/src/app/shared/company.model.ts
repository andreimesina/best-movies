export class Company {
    id: number;
    name: string;
    
    movieName: string[];
    movieId: number[];
  
    constructor(input?: any) {
      Object.assign(this, input);
    }
  }