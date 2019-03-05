import { Ability } from './ability';
import { Form } from './form';
import { GameIndice } from './game_indice';
import { Move } from './Move';
import { Species } from './species';
import { Sprite } from './Sprite';
import { Stat } from './Stat';
import { Type } from './Type';

export interface Pokemon {
    abilities?: Ability[];
    base_experience: number;
    forms?: Form[];
    game_indices?: GameIndice[];
    height: number;
    id: number;
    is_default: boolean;
    location_area_encounters: string;
    moves: Move[];
    name: string;
    order: number;
    species: Species[];
    sprites: Sprite[];
    stats: Stat[];
    types: Type[];
    weight: number;
}
