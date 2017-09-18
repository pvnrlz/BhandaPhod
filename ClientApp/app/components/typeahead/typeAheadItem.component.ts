
import { Component, ChangeDetectorRef } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import {
    resolveNextIndex,
    validateArrowKeys,
    isIndexActive
} from './typeahead.util';

import { Key } from './typeahead.model';


@Component({
    selector: 'typeaheaditem',
    template: ``
})
export class TypeAheadItemComponent {

    constructor(private cdr: ChangeDetectorRef) { }

    private suggestionIndex = 0;
    private activeResult: string;

    navigateWithArrows(elementObs: Observable<{}>) {
        return elementObs
            .filter((e: any) => validateArrowKeys(e.keyCode))
            .map((e: any) => e.keyCode)
            .subscribe((keyCode: number) => {
                this.suggestionIndex = resolveNextIndex(
                    this.suggestionIndex,
                    keyCode === Key.ArrowDown
                );
                this.cdr.markForCheck();
            });
    }
    markIsActive(index: number, result: string) {
        const isActive = isIndexActive(index, this.suggestionIndex);
        if (isActive) {
            this.activeResult = result;
        }
        return isActive;
    }
    
}
