import { animate, animation, keyframes, style } from '@angular/animations';

export let dropDown = animation([
    animate('250ms ease-in', keyframes([
        style({ opacity: 0, transform: 'translateY(-60px)', offset: 0 }),
        style({ opacity: .5, transform: 'translateY(30px)', offset: 0.3 }),
        style({ opacity: 1, transform: 'translateY(0)', offset: 1.0 }),
    ]))
]);
export let dropDownSmall = animation([
    animate('250ms ease-in', keyframes([
        style({ opacity: 0, transform: 'translateY(0)', offset: 0 }),
        style({ opacity: .5, transform: 'translateY(5px)', offset: 0.3 }),
        style({ opacity: 1, transform: 'translateY(0)', offset: 1.0 }),
    ]))
]);
export let dropDownDeep = animation([
    animate('350ms ease-in', keyframes([
        style({ opacity: 0, transform: 'translateY(-50px)', offset: 0 }),
        style({ opacity: .5, transform: 'translateY(20px)', offset: 0.3 }),
        style({ opacity: .5, transform: 'translateY(-5px)', offset: 0.8 }),
        style({ opacity: 1, transform: 'translateY(0)', offset: 1.0 })
    ]))
]);
export let dropDownDeepAndUp = animation([
    animate('350ms ease-in', keyframes([
        style({ opacity: 0, transform: 'translateY(-50px)', offset: 0 }),
        style({ opacity: .5, transform: 'translateY(30px)', offset: 0.3 }),
        style({ opacity: .8, transform: 'translateY(-10px)', offset: 0.8 }),
        style({ opacity: 1, transform: 'translateY(0)', offset: 1.0 })
    ]))
]);

export let dropUpAnimation = animation([
    animate('250ms ease-in', keyframes([
        style({ opacity: 1, transform: 'translateY(0)', offset: 0 }),
        style({ opacity: .5, transform: 'translateY(35px)', offset: 0.3 }),
        style({ opacity: 0, transform: 'translateY(-75%)', offset: 1.0 }),
    ]))
]);
 
export let bigToNormal = animation([
    //Initial state
    style({
        height: 0,
        opacity: 0,
        transform: 'scale(1.7)',
        'margin-bottom': 0,
        //Due to bugs in Firefox and other browsers 'expand' out the padding, 
        //that define padding for each direction. 
        paddingTop: 0,
        paddingBottom: 0,
        paddingLeft: 0,
        paddingRight: 0
    }),
    //First animate spacing which includes heights and margin. 
    animate('50ms', style({
        height: '*',
        'margin-bottom': '*',
        paddingTop: '*',
        paddingBottom: '*',
        paddingLeft: '*',
        paddingRight: '*'
    })),
    animate('400ms ease-out')
]);

 
export let bigToNormalSmallAnimation = animation([
    //Initial state
    style({
        height: 0,
        opacity: 0,
        transform: 'scale(1.1)',
        'margin-bottom': 0,
        //Due to bugs in Firefox and other browsers 'expand' out the padding, 
        //that define padding for each direction. 
        paddingTop: 0,
        paddingBottom: 0,
        paddingLeft: 0,
        paddingRight: 0
    }),
    //First animate spacing which includes heights and margin. 
    animate('50ms', style({
        height: '*',
        'margin-bottom': '*',
        paddingTop: '*',
        paddingBottom: '*',
        paddingLeft: '*',
        paddingRight: '*'
    })),
    animate('400ms ease-out')
]);

export let smallToNormal = animation([
    //Initial state
    style({
        height: 0,
        opacity: 0,
        transform: 'scale(0.80)',
        'margin-bottom': 0,
        //Due to bugs in Firefox and other browsers 'expand' out the padding, 
        //that define padding for each direction. 
        paddingTop: 0,
        paddingBottom: 0,
        paddingLeft: 0,
        paddingRight: 0
    }),
    //First animate spacing which includes heights and margin. 
    animate('80ms', style({
        height: '*',
        'margin-bottom': '*',
        paddingTop: '*',
        paddingBottom: '*',
        paddingLeft: '*',
        paddingRight: '*'
    })),
    animate(200)

]);