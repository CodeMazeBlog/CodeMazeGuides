import com.sun.management.ThreadMXBean;
import java.lang.management.ManagementFactory;

void main() {
    final int count = 1_000_000;
    var threads = (ThreadMXBean) ManagementFactory.getThreadMXBean();
    long before = threads.getCurrentThreadAllocatedBytes();

    var quantities = new ArrayList<Integer>(count);
    for (int i = 0; i < count; i++) {
        quantities.add(i);
    }

    long allocated = threads.getCurrentThreadAllocatedBytes() - before;
    IO.println("ArrayList<Integer> with %,d items: %.1f MB allocated"
        .formatted(quantities.size(), allocated / 1_000_000.0));
}
