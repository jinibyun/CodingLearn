/*
Generates an observable sequence by running a state-driven loop producing the sequence's elements, 
using the specified scheduler to send out observer messages.
*/

import { generate } from 'rxjs';

generate(2, x => x <= 8, x => x + 3).subscribe(console.log);

/*
OUTPUT:
2
5
8
*/