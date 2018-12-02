import { Component, OnInit } from '@angular/core';
import { PokedexService } from '../_services/pokedex.service';
import { forEach } from '@angular/router/src/utils/collection';

@Component({
  selector: 'app-pokemons',
  templateUrl: './pokemons.component.html',
  styleUrls: ['./pokemons.component.css']
})
export class PokemonsComponent implements OnInit {

  result: any;
  pokemons: any;
  constructor(private pokedex: PokedexService) { }

  ngOnInit() {
    this.getPokemons();
  }

  getPokemons() {
    this.pokedex.getPokemons().subscribe(
      data => this.pokemons = data
    );
  }

}
