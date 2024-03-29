import { MyTranslatorPipe } from './my-translator.pipe';

describe('MyTranslatorPipe', () => {
    it('create an instance', () => {
        const pipe = new MyTranslatorPipe();
        expect(pipe).toBeTruthy();
    });
});
