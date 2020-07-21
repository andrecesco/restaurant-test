import { Validators } from '@angular/forms';

export class FormOrder {
  public order: string;
}

export const CreateOptions = {
  order: ["", [Validators.minLength(10)]]
};

export const CreateValidations = {
};
