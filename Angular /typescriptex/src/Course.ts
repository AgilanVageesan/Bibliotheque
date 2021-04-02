export function Course(config:any) {
    return function(target:any) {
        Object.defineProperty(target.prototype, "subject", {
            "value" : config.name });
    
    }
}

