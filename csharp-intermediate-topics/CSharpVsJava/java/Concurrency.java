void main() throws Exception {
    long start = System.nanoTime();

    try (var executor = Executors.newVirtualThreadPerTaskExecutor()) {
        var checks = IntStream.rangeClosed(1, 10_000)
            .mapToObj(id -> executor.submit(() -> getStock(id)))
            .toList();
        for (var check : checks) {
            check.get();
        }
    }

    long elapsed = Duration.ofNanos(System.nanoTime() - start).toMillis();
    IO.println("%,d stock checks in %,d ms".formatted(10_000, elapsed));
}

int getStock(int productId) throws InterruptedException {
    Thread.sleep(Duration.ofSeconds(1)); // stands in for a database or HTTP call
    return productId % 7;
}
