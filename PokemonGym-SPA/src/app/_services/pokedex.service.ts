import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PokedexService {

  baseUrl = 'https://pokeapi.co/api/v2/pokemon/';

constructor(private http: HttpClient) { }

  getPokemons() {
    return this.http.get(this.baseUrl);
  }

  getPokemon(url) {
    return this.http.get(url);
  }
}
